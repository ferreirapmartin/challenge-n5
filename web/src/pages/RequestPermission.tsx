import { useNavigate } from 'react-router-dom';
import { PermissionDetail } from '../components';
import { permissionRequestRequested } from '../state';
import { PermissionForm } from '../types';

const RequestPermission = () => {
  const navigate = useNavigate();
  const handleCancelEdit = () => {
    navigate('/');
  };
  const saveActionHandle = (permission: PermissionForm) => {
    handleCancelEdit();
    return permissionRequestRequested(permission);
  };
  return (
    <PermissionDetail
      title="Request Permission"
      saveAction={saveActionHandle}
      handleCancel={handleCancelEdit}
    />
  );
};

export default RequestPermission;
