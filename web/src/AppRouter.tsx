import { createBrowserRouter } from 'react-router-dom';
import { Permission, ErrorPage, RequestPermission } from './pages';
import { Layout } from './layout';

export const router = createBrowserRouter([
  {
    path: '/',
    element: <Layout />,
    errorElement: <Layout outlet={<ErrorPage />} />,
    children: [
      {
        path: '',
        element: <Permission />,
        children: [
          {
            path: '/request',
            element: <RequestPermission />,
          },
        ],
      },
    ],
  },
]);
