import { Button, Menu, MenuItem } from '@mui/material';
import { useState, MouseEvent, useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useTranslation } from 'react-i18next';
import { changeLang, langSelector } from '../state';
import { supportedLngs } from '../config';
import { AppStorage } from '../services';

const LanguagePicker = () => {
  const dispatch = useDispatch();
  const { t, i18n } = useTranslation();
  const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
  const open = Boolean(anchorEl);
  const handleClick = (event: MouseEvent<HTMLButtonElement>) => setAnchorEl(event.currentTarget);
  const handleClose = () => setAnchorEl(null);
  const handleItemClick = (newLang: string) => () => {
    dispatch(changeLang(newLang));
    handleClose();
  };
  const lang = useSelector(langSelector);

  useEffect(() => {
    if (i18n.language !== lang) {
      i18n.changeLanguage(lang);
      AppStorage.setUserLang(lang);
    }
  }, [lang]);

  return (
    <div>
      <Button
        id="language-picker"
        aria-controls={open ? 'language-menu' : undefined}
        aria-haspopup="true"
        aria-expanded={open ? 'true' : undefined}
        onClick={handleClick}
      >
        {t(`languages.${lang}`)}
      </Button>
      <Menu
        id="language-menu"
        anchorEl={anchorEl}
        open={open}
        onClose={handleClose}
        MenuListProps={{ 'aria-labelledby': 'language-picker' }}
      >
        {supportedLngs.map(i => (
          <MenuItem key={i} onClick={handleItemClick(i)} disabled={i === lang}>
            {t(`languages.${i}`)}
          </MenuItem>
        ))}
      </Menu>
    </div>
  );
};

export default LanguagePicker;
