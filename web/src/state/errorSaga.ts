import { PayloadAction } from '@reduxjs/toolkit';
import { put, takeLatest } from 'redux-saga/effects';
import { HttpRequestError } from '../types';
import { enqueueNotification } from './userSlice';

function* handleRequestErrors() {
  yield put(
    enqueueNotification({
      key: 'error',
      message: t => t('errors.unexpected'),
      variant: 'error',
    }),
  );
}

export default function* permissionSaga() {
  yield takeLatest(
    (action: PayloadAction<HttpRequestError>) => /Failure$/.test(action.type) as any,
    handleRequestErrors,
  );
}
