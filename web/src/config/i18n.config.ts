import i18n from 'i18next';
import { setLocale } from 'yup';
import { initReactI18next } from 'react-i18next';
import { esES as esMiu, enUS as enMui } from '@mui/material/locale';
import { esES as esDataGridMui, enUS as enDataGridMui } from '@mui/x-data-grid/locales';
import { Localization } from '@mui/x-data-grid/utils/getGridLocalization';
import i18nBackend from 'i18next-http-backend';

export type SupportedLanguages = 'es' | 'en';

export const supportedLngs: SupportedLanguages[] = ['en', 'es'];

export const muiLocales: Record<SupportedLanguages, Localization> = {
  es: { ...esMiu, ...esDataGridMui },
  en: { ...enMui, ...enDataGridMui },
};

setLocale({
  mixed: {
    required: () => i18n.t('validations.required'),
  },
});

i18n
  .use(i18nBackend)
  .use(initReactI18next)
  .init({
    fallbackLng: supportedLngs[0],
    debug: true,
    supportedLngs,
    interpolation: {
      escapeValue: false,
    },
  });

export default i18n;
