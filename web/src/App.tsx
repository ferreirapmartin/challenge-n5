import { Provider } from 'react-redux';
import { ThemeProvider } from '@mui/material';
import { RouterProvider } from 'react-router-dom';
import { store, theme } from './config';
import { router } from './AppRouter';

const App = () => (
  <ThemeProvider theme={theme}>
    <Provider store={store}>
      <RouterProvider router={router} />
    </Provider>
  </ThemeProvider>
);

export default App;
