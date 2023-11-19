import { ThemeOptions, createTheme } from '@mui/material';
import { blue, indigo, purple } from '@mui/material/colors';
import { SupportedLanguages, muiLocales } from './i18n.config';
import { ThemeSupported } from '../types';

const themeDefault: ThemeOptions = {
  palette: {
    primary: {
      main: indigo[500],
    },
  },
};

const themeBlue: ThemeOptions = {
  palette: {
    background: {
      default: '#cae4ff',
    },
    primary: {
      main: blue[500],
    },
  },
};

const themePurple: ThemeOptions = {
  palette: {
    background: {
      default: '#f9b4ff',
    },
    primary: {
      main: purple[500],
    },
  },
};

export const supportedThemes: Record<ThemeSupported, ThemeOptions> = {
  default: themeDefault,
  blue: themeBlue,
  purple: themePurple,
};

const themeFactory = (themeName: ThemeSupported, lang: string) =>
  createTheme(supportedThemes[themeName], muiLocales[lang as SupportedLanguages]);

export default themeFactory;
