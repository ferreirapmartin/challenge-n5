import { combineReducers, configureStore } from '@reduxjs/toolkit';
import createSagaMiddleware from 'redux-saga';
import { all } from 'redux-saga/effects';
import permissionReducer from '../state/permissionSlice';
import userReducer from '../state/userSlice';
import { permissionSaga, errorSaga } from '../state';

const sagaMiddleWare = createSagaMiddleware();

const store = configureStore({
  reducer: combineReducers({ user: userReducer, permission: permissionReducer }),
  middleware: [sagaMiddleWare],
});

function* rootSaga() {
  yield all([permissionSaga(), errorSaga()]);
  // code after all-effect
}

sagaMiddleWare.run(rootSaga);

export type RootState = ReturnType<typeof store.getState>;

export default store;
