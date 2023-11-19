import { useEffect } from 'react';
import {
  DataGrid,
  GridActionsCellItem,
  GridColDef,
  GridRowParams,
  GridValueGetterParams,
} from '@mui/x-data-grid';
import { useDispatch, useSelector } from 'react-redux';
import EditIcon from '@mui/icons-material/Edit';
import { useTranslation } from 'react-i18next';
import { findPermissionRequested, permissionSelector, setPermissionEdit } from '../state';
import { Permission } from '../types';


const pageSizeOptions = [10];

const initialState = {
  pagination: {
    paginationModel: {
      pageSize: pageSizeOptions[0],
    },
  },
};

const PermissionTable = () => {
  const { t } = useTranslation();
  const dispatch = useDispatch();
  const permissions = useSelector(permissionSelector);

  useEffect(() => {
    dispatch(findPermissionRequested());
  }, []);

  const editHandler = (permission: Permission) => {
    dispatch(setPermissionEdit(permission));
  };

  const columns: GridColDef<Permission>[] = [
    { field: 'id', headerName: 'ID', width: 90 },
    {
      field: 'forename',
      headerName: t('permissions.labels.forename'),
      width: 150,
    },
    {
      field: 'surname',
      headerName: t('permissions.labels.surname'),
      width: 150,
    },
    {
      field: 'createdDate',
      headerName: t('permissions.labels.createdDate'),
      type: 'date',
      width: 130,
    },
    {
      field: 'permissionType',
      headerName: t('permissions.labels.permissionType'),
      sortable: false,
      width: 220,
      valueGetter: (params: GridValueGetterParams) => params.row.type.description,
    },
    {
      field: 'actions',
      type: 'actions',
      getActions: (params: GridRowParams) => [
        <GridActionsCellItem
          icon={<EditIcon />}
          onClick={() => editHandler(params.row)}
          label={t('common.modify')}
        />,
      ],
    },
  ];

  return (
    <DataGrid
      rows={permissions}
      columns={columns}
      initialState={initialState}
      pageSizeOptions={pageSizeOptions}
      disableRowSelectionOnClick
      rowHeight={38}
    />
  );
};

export default PermissionTable;
