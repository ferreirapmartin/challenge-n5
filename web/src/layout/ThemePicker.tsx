import { Button, Menu, MenuItem } from '@mui/material';
import { useState, MouseEvent, useMemo } from 'react';
import { useTranslation } from 'react-i18next';
import { useDispatch, useSelector } from 'react-redux';
import { changeTheme, themeSelector } from '../state';
import { supportedThemes } from '../config';
import { AppStorage } from '../services';
import { ThemeSupported } from '../types';

const ThemePicker = () => {
  const { t } = useTranslation();
  const dispatch = useDispatch();
  const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
  const open = Boolean(anchorEl);
  const handleClick = (event: MouseEvent<HTMLButtonElement>) => setAnchorEl(event.currentTarget);
  const handleClose = () => setAnchorEl(null);
  const handleItemClick = (newTheme: string) => () => {
    dispatch(changeTheme(newTheme as ThemeSupported));
    AppStorage.setUserTheme(newTheme as ThemeSupported);
    handleClose();
  };
  const theme = useSelector(themeSelector);
  const supportedThemesKeys = useMemo(() => Object.keys(supportedThemes), [supportedThemes]);

  return (
    <div>
      <Button
        id="theme-picker"
        aria-controls={open ? 'theme-menu' : undefined}
        aria-haspopup="true"
        aria-expanded={open ? 'true' : undefined}
        onClick={handleClick}
      >
        {t(`theme.title`, { theme })}
      </Button>
      <Menu
        id="theme-menu"
        anchorEl={anchorEl}
        open={open}
        onClose={handleClose}
        MenuListProps={{ 'aria-labelledby': 'theme-picker' }}
      >
        {supportedThemesKeys.map(i => (
          <MenuItem key={i} onClick={handleItemClick(i)} disabled={i === theme}>
            {t(`theme.${i}`)}
          </MenuItem>
        ))}
      </Menu>
    </div>
  );
};

export default ThemePicker;
