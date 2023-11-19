import { ReactNode } from 'react';
import * as yup from 'yup';
import { useFormik } from 'formik';
import {
  DialogContent,
  DialogTitle,
  Dialog,
  TextField,
  Button,
  Stack,
  FormControl,
  InputLabel,
  Select,
  MenuItem,
  FormHelperText,
} from '@mui/material';
import { AnyAction } from '@reduxjs/toolkit';
import { Trans, useTranslation } from 'react-i18next';
import { useDispatch, useSelector } from 'react-redux';
import { Permission, PermissionForm } from '../types';
import { permissionTypeSelector } from '../state';

interface Props {
  title: ReactNode;
  permission?: Permission | null;
  saveAction: (permission: PermissionForm) => AnyAction;
  handleCancel: () => void;
}

const validationSchema = yup.object({
  forename: yup
    .string()
    .required()
    .matches(/^(?!\s+$).*/, { message: <Trans i18nKey="validations.required" /> }),
  surname: yup
    .string()
    .required()
    .matches(/^(?!\s+$).*/, { message: <Trans i18nKey="validations.required" /> }),
  type: yup.number().required(),
});

const PermissionDetail = ({ permission, title, saveAction, handleCancel }: Props) => {
  const { t } = useTranslation();
  const permissionType = useSelector(permissionTypeSelector);
  const dispatch = useDispatch();
  const handleSubmit = (values: PermissionForm) => {
    dispatch(saveAction(values));
  };

  const formik = useFormik<PermissionForm>({
    initialValues: {
      id: permission?.id || -1,
      forename: permission?.forename || '',
      surname: permission?.surname || '',
      type: permission?.type?.id || '',
    },
    validationSchema,
    onSubmit: handleSubmit,
  });

  const canSave = formik.isValid && formik.dirty;

  return (
    <Dialog onClose={handleCancel} open>
      <DialogTitle>{title}</DialogTitle>
      <DialogContent>
        <form onSubmit={formik.handleSubmit}>
          <Stack spacing={1.5}>
            <TextField
              fullWidth
              id="forename"
              name="forename"
              label={t('permissions.labels.forename')}
              value={formik.values.forename}
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
              error={formik.touched.forename && Boolean(formik.errors.forename)}
              helperText={formik.touched.forename && formik.errors.forename}
              variant="standard"
            />
            <TextField
              fullWidth
              id="surname"
              name="surname"
              label={t('permissions.labels.surname')}
              value={formik.values.surname}
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
              error={formik.touched.surname && Boolean(formik.errors.surname)}
              helperText={formik.touched.surname && formik.errors.surname}
              variant="standard"
            />
            <FormControl fullWidth>
              <InputLabel variant="standard" id="type-label">
                {t('permissions.labels.permissionType')}
              </InputLabel>
              <Select
                id="type"
                name="type"
                labelId="type-label"
                label={t('permissions.labels.permissionType')}
                value={formik.values.type}
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
                error={formik.touched.type && Boolean(formik.errors.type)}
                variant="standard"
              >
                {permissionType.map(i => (
                  <MenuItem key={i.id} value={i.id}>
                    {i.description}
                  </MenuItem>
                ))}
              </Select>
              {formik.errors.type && (
                <FormHelperText variant="standard" sx={{ color: 'error.main' }}>
                  {formik.errors.type}
                </FormHelperText>
              )}
            </FormControl>
            <Stack direction="row" spacing={5}>
              <Button color="primary" fullWidth type="button" onClick={handleCancel}>
                {t('common.cancel')}
              </Button>
              <Button
                color="primary"
                variant="contained"
                fullWidth
                type="submit"
                disabled={!canSave}
              >
                {t('common.save')}
              </Button>
            </Stack>
          </Stack>
        </form>
      </DialogContent>
    </Dialog>
  );
};

export default PermissionDetail;
