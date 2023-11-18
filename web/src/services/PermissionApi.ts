import { axionsIntance } from '../config';
import { Permission, PermissionForm } from '../types';

export type FindPermissionsResponse = {
  id: number;
  forename: string;
  surname: string;
  typeId: number;
  typeDescription: string;
  createdDate: string;
}[];

export interface RequestPermissionRequest {
  forename: string;
  surname: string;
  type: number;
}

export default class {
  static async findPermissions(): Promise<Permission[]> {
    const { data } = await axionsIntance.get<FindPermissionsResponse>(`/permission`);

    return data.map(i => ({
      id: i.id,
      forename: i.forename,
      surname: i.surname,
      type: { id: i.typeId, description: i.typeDescription },
      createdDate: new Date(Date.parse(i.createdDate)),
    }));
  }

  static async requestPermission(request: PermissionForm) {
    return axionsIntance.post(`/permission`, request);
  }

  static async modifyPermission(request: PermissionForm) {
    const { id, ...data } = request;
    return axionsIntance.put(`/permission/${id}`, data);
  }
}
