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
} from './permissionSlice';
import { Permission, PermissionForm } from '../types';
import { PermissionApi } from '../services';

function* findPermissions() {
  try {
    const permissions: Permission[] = yield call(PermissionApi.findPermissions);
    yield put(findPermissionSuccess(permissions));
  } catch (err) {
    yield put(findPermissionFailure());
  }
}

function* modifyPermission({ payload }: PayloadAction<PermissionForm>) {
  try {
    yield call(PermissionApi.modifyPermission, payload);
    yield put(permissionModifySuccess());
  } catch (err) {
    yield put(permissionModifyFailure());
  }
}

function* onPermissionModifySuccess() {
  yield put(findPermissionRequested());
}

function* requestPermission({ payload }: PayloadAction<PermissionForm>) {
  try {
    yield call(PermissionApi.requestPermission, payload);
    yield put(permissionModifySuccess());
  } catch (err) {
    yield put(permissionModifyFailure());
  }
}

function* onPermissionRequestSuccess() {
  yield put(findPermissionRequested());
}

export default function* catalogueSaga() {
  yield takeLatest(findPermissionRequested.type, findPermissions);
  yield takeLatest(permissionModifyRequested.type, modifyPermission);
  yield takeLatest(permissionModifySuccess.type, onPermissionModifySuccess);
  yield takeLatest(permissionRequestRequested.type, requestPermission);
  yield takeLatest(permissionRequestSuccess.type, onPermissionRequestSuccess);
}
