import { ThemeSupported } from '../types';

const LANG_KEY = 'user-lang';
const THEME_KEY = 'user-theme';

class AppStorage {
  static setUserLang(lang: string) {
    localStorage.setItem(LANG_KEY, lang);
  }

  static getUserLang(): string | null {
    return localStorage.getItem(LANG_KEY);
  }

  static setUserTheme(themeName: ThemeSupported) {
    localStorage.setItem(THEME_KEY, themeName);
  }

  static getUserTheme(): ThemeSupported | null {
    return localStorage.getItem(THEME_KEY) as ThemeSupported | null;
  }
}

export default AppStorage;
