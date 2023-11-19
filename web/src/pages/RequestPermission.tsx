import { useNavigate } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import { PermissionDetail } from '../components';
import { permissionRequestRequested } from '../state';
import { PermissionForm } from '../types';

const RequestPermission = () => {
  const navigate = useNavigate();
  const { t } = useTranslation();
  const handleCancelEdit = () => navigate('/');
  const saveActionHandle = (permission: PermissionForm) => {
    handleCancelEdit();
    return permissionRequestRequested(permission);
  };
  return (
    <PermissionDetail
      title={t('permissions.request.title')}
      saveAction={saveActionHandle}
      handleCancel={handleCancelEdit}
    />
  );
};

export default RequestPermission;
