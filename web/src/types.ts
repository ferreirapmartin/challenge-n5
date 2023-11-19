import { AxiosError } from 'axios';

export interface PermissionType {
  id: number;
  description: string;
}

export interface Permission {
  id: number;
  forename: string;
  surname: string;
  type: PermissionType;
  createdDate: Date;
}

export interface PermissionForm {
  id?: number;
  forename: string;
  surname: string;
  type: number | '';
}

export type ThemeSupported = 'default' | 'blue' | 'purple';

export interface UserNotification {
  variant: 'error' | 'success' | 'warning' | 'info';
  key: string;
  message: (t: any) => string;
  duration?: number;
}

export interface HttpRequestError {
  notified: boolean;
  code: number;
  data?: object;
  innerException?: AxiosError;
}
