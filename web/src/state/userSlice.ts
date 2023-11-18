import { createSlice, PayloadAction } from '@reduxjs/toolkit';

interface LayoutState {
  lang: string;
}

const initialState: LayoutState = {
  lang: 'es',
};

export const userSlice = createSlice({
  name: 'user',
  initialState,
  reducers: {
    changeLang: (state, { payload }: PayloadAction<string>) => {
      state.lang = payload;
    },
  },
});

export const { changeLang } = userSlice.actions;

export default userSlice.reducer;
