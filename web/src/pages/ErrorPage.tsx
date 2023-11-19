import { useTranslation } from 'react-i18next';
import { useRouteError } from 'react-router-dom';

const ErrorPage = () => {
  const error: any = useRouteError();
  const { t } = useTranslation();

  console.error(error);

  return (
    <div id="error-page">
      <h1>Oops!</h1>
      <p>{t('errors.unexpected')}</p>
      <p>
        <i>{error.statusText || error.message}</i>
      </p>
    </div>
  );
};

export default ErrorPage;
