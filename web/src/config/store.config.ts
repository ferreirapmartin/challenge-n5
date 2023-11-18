import { combineReducers, configureStore } from '@reduxjs/toolkit';
import createSagaMiddleware from 'redux-saga';

import permissionReducer from '../state/permissionSlice';
import userReducer from '../state/userSlice';
import { permissionSaga } from '../state';

const sagaMiddleWare = createSagaMiddleware();

const store = configureStore({
  reducer: combineReducers({ user: userReducer, permission: permissionReducer }),
  middleware: [sagaMiddleWare],
});

sagaMiddleWare.run(permissionSaga);

export type RootState = ReturnType<typeof store.getState>;

export default store;
