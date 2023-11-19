import { Suspense } from 'react';
import { Provider } from 'react-redux';
import { RouterProvider } from 'react-router-dom';
import { SnackbarProvider } from 'notistack';
import { store } from './config';
import { router } from './AppRouter';
import './config/i18n.config';
import { Notifier, ThemeSwitcherProvider } from './components';


const App = () => (
  <Suspense fallback="Loading ...">
    <Provider store={store}>
      <SnackbarProvider maxSnack={3}>
        <Notifier />
        <ThemeSwitcherProvider>
          <RouterProvider router={router} />
        </ThemeSwitcherProvider>
      </SnackbarProvider>
    </Provider>
  </Suspense>
);

export default App;
