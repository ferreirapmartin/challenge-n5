import { useSelector, useDispatch } from 'react-redux';
import { Button, Stack, Typography } from '@mui/material';
import styled from '@emotion/styled';
import { useTranslation } from 'react-i18next';
import { Outlet, useNavigate } from 'react-router-dom';
import { PermissionDetail, PermissionTable } from '../components';
import { permissionEditSelector, permissionModifyRequested, setPermissionEdit } from '../state';

const ActionContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: end;
`;

const Permission = () => {
  const { t } = useTranslation();
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const permissionEdit = useSelector(permissionEditSelector);
  const handleCancelEdit = () => {
    dispatch(setPermissionEdit(null));
  };
  const clickHandler = () => {
    navigate('/request');
  };
  return (
    <>
      <Stack spacing={2}>
        <Typography variant="h3">{t('permissions.title')}</Typography>
        <ActionContainer>
          <Button onClick={clickHandler} size="small">
            {t('permissions.request.title')}
          </Button>
        </ActionContainer>
        <PermissionTable />
      </Stack>
      {permissionEdit && (
        <PermissionDetail
          title={t('permissions.modify.title')}
          permission={permissionEdit}
          saveAction={permissionModifyRequested}
          handleCancel={handleCancelEdit}
        />
      )}
      <Outlet />
    </>
  );
};

export default Permission;
