import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { Permission, PermissionType, PermissionForm } from '../types';
import { RootState } from '../config';

interface PermissionState {
  permissions: Permission[];
  permissionsTypes: PermissionType[];
  loading: boolean;
  error: boolean;
  permissionEdit: Permission | null;
  permissionForm: PermissionForm | null;
}

// FIXME: se debería traer de una API, pero como solo se piden 3 servicios en el challenge, se dejó así
const permissionsTypes: PermissionType[] = [
  { id: 1, description: 'ADMIN' },
  { id: 2, description: 'READ_WRITE' },
  { id: 3, description: 'WRITE' },
  { id: 4, description: 'READ' },
];

const initialState: PermissionState = {
  permissions: [],
  permissionsTypes,
  loading: false,
  error: false,
  permissionEdit: null,
  permissionForm: null,
};

export const permissionSlice = createSlice({
  name: 'permissions',
  initialState,
  reducers: {
    findPermissionRequested: state => {
      state.permissions = [];
      state.error = false;
      state.loading = true;
    },
    findPermissionSuccess: (state, { payload }: PayloadAction<Permission[]>) => {
      state.permissions = payload;
      state.error = false;
      state.loading = false;
    },
    findPermissionFailure: state => {
      state.permissions = [];
      state.error = true;
      state.loading = false;
    },
    setPermissionEdit: (state, { payload }: PayloadAction<Permission | null>) => {
      state.permissionEdit = payload;
      state.permissionForm = null;
    },
    permissionModifyRequested: (state, { payload }: PayloadAction<PermissionForm>) => {
      state.permissionEdit = null;
      state.permissionForm = payload;
    },
    permissionModifySuccess: state => {
      state.permissionForm = null;
    },
    permissionModifyFailure: state => {
      state.permissionForm = null;
    },
    permissionRequestRequested: (state, { payload }: PayloadAction<PermissionForm>) => {
      state.permissionEdit = null;
      state.permissionForm = payload;
    },
    permissionRequestSuccess: state => {
      state.permissionForm = null;
    },
    permissionRequestFailure: state => {
      state.permissionForm = null;
    },
  },
});

//

export const {
  findPermissionRequested,
  findPermissionSuccess,
  findPermissionFailure,
  setPermissionEdit,
  permissionModifyFailure,
  permissionModifyRequested,
  permissionModifySuccess,
  permissionRequestFailure,
  permissionRequestRequested,
  permissionRequestSuccess,
} = permissionSlice.actions;

// Selectors
export const permissionSelector = (state: RootState) => state.permission.permissions;
export const permissionTypeSelector = (state: RootState) => state.permission.permissionsTypes;
export const isPermissionLoadingSelector = (state: RootState) => state.permission.loading;
export const hasPermissionErrorSelector = (state: RootState) => state.permission.error;
export const permissionEditSelector = (state: RootState) => state.permission.permissionEdit;
export const permissionFormSelector = (state: RootState) => state.permission.permissionForm;

export default permissionSlice.reducer;
