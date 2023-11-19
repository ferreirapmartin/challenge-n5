import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useSnackbar } from 'notistack';
import { useTranslation } from 'react-i18next';
import { dequeueNotification, notificationsSelector } from '../state';

const Notifier = () => {
  const dispatch = useDispatch();
  const { t } = useTranslation();
  const notifications = useSelector(notificationsSelector);
  const { enqueueSnackbar } = useSnackbar();

  useEffect(() => {
    notifications.forEach(({ key, message, variant, duration }) => {
      enqueueSnackbar(message(t), {
        key,
        variant,
        autoHideDuration: duration || 6000,
        preventDuplicate: true,
        anchorOrigin: { vertical: 'bottom', horizontal: 'right' },
      });
      dispatch(dequeueNotification(key));
    });
  }, [notifications]);

  return null;
};

export default Notifier;
