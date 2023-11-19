import { ThemeProvider } from '@mui/material';
import { ReactNode, useMemo } from 'react';
import { useSelector } from 'react-redux';
import { themeFactory } from '../config';
import { langSelector, themeSelector } from '../state';


interface Props {
  children: ReactNode;
}

const ThemeSwitcherProvider = ({ children }: Props) => {
  const lang = useSelector(langSelector);
  const theme = useSelector(themeSelector);
  const themeSelected = useMemo(() => themeFactory(theme, lang), [lang, theme]);

  return <ThemeProvider theme={themeSelected}>{children}</ThemeProvider>;
};

export default ThemeSwitcherProvider;
