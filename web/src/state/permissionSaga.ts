import { call, put, takeLatest } from 'redux-saga/effects';
import { PayloadAction } from '@reduxjs/toolkit';
import {
  findPermissionFailure,
  findPermissionSuccess,
  findPermissionRequested,
  permissionModifyRequested,
  permissionModifySuccess,
  permissionModifyFailure,
  permissionRequestRequested,
  permissionRequestSuccess,
  permissionRequestFailure,
} from './permissionSlice';
import { HttpRequestError, Permission, PermissionForm } from '../types';
import { PermissionApi } from '../services';
import { enqueueNotification } from './userSlice';

function* findPermissions() {
  try {
    const permissions: Permission[] = yield call(PermissionApi.findPermissions);
    yield put(findPermissionSuccess(permissions));
  } catch (err) {
    yield put(findPermissionFailure(err as HttpRequestError));
  }
}

function* modifyPermission({ payload }: PayloadAction<PermissionForm>) {
  try {
    yield call(PermissionApi.modifyPermission, payload);
    yield put(permissionModifySuccess());
  } catch (err) {
    yield put(permissionModifyFailure(err as HttpRequestError));
  }
}

function* onPermissionModifySuccess() {
  yield put(
    enqueueNotification({
      key: 'permissionModifySuccess',
      message: t => t('notifications.permissionModifySuccess'),
      variant: 'success',
    }),
  );
  yield put(findPermissionRequested());
}

function* requestPermission({ payload }: PayloadAction<PermissionForm>) {
  try {
    yield call(PermissionApi.requestPermission, payload);
    yield put(permissionRequestSuccess());
  } catch (err) {
    yield put(permissionRequestFailure(err as HttpRequestError));
  }
}

function* onPermissionRequestSuccess() {
  yield put(
    enqueueNotification({
      key: 'permissionRequestSuccess',
      message: t => t('notifications.permissionRequestSuccess'),
      variant: 'success',
    }),
  );
  yield put(findPermissionRequested());
}

export default function* permissionSaga() {
  yield takeLatest(findPermissionRequested.type, findPermissions);
  yield takeLatest(permissionModifyRequested.type, modifyPermission);
  yield takeLatest(permissionModifySuccess.type, onPermissionModifySuccess);
  yield takeLatest(permissionRequestRequested.type, requestPermission);
  yield takeLatest(permissionRequestSuccess.type, onPermissionRequestSuccess);
}
