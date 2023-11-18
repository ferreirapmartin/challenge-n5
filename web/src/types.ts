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
