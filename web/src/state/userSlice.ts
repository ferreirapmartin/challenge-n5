import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { RootState } from '../config';
import { AppStorage } from '../services';
import { ThemeSupported, UserNotification } from '../types';

interface LayoutState {
  lang: string;
  theme: ThemeSupported;
  notifications: UserNotification[];
}

const initialState: LayoutState = {
  lang: AppStorage.getUserLang() || 'en',
  theme: AppStorage.getUserTheme() || 'default',
  notifications: [],
};

export const userSlice = createSlice({
  name: 'user',
  initialState,
  reducers: {
    changeLang: (state, { payload }: PayloadAction<string>) => {
      state.lang = payload;
    },
    changeTheme: (state, { payload }: PayloadAction<ThemeSupported>) => {
      state.theme = payload;
    },
    enqueueNotification: (
      state,
      { payload }: PayloadAction<UserNotification | UserNotification[]>,
    ) => {
      state.notifications = Array.isArray(payload)
        ? [...state.notifications, ...payload]
        : [...state.notifications, payload];
    },
    dequeueNotification: (state, { payload: notificationId }: PayloadAction<string | string[]>) => {
      state.notifications = Array.isArray(notificationId)
        ? state.notifications.filter(i => !notificationId.includes(i.key))
        : state.notifications.filter(i => i.key !== notificationId);
    },
  },
});

// Selectors
export const langSelector = (state: RootState) => state.user.lang;
export const themeSelector = (state: RootState) => state.user.theme;
export const notificationsSelector = (state: RootState) => state.user.notifications;

export const { changeLang, changeTheme, enqueueNotification, dequeueNotification } =
  userSlice.actions;

export default userSlice.reducer;
