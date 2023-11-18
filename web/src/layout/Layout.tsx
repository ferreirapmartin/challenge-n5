import { Box, Container, CssBaseline } from '@mui/material';
import styled from '@emotion/styled';
import { ReactNode } from 'react';
import { Outlet } from 'react-router-dom';
import Footer from './Footer';

interface LayoutProps {
  outlet?: ReactNode;
}

const Main = styled(Box)`
  display: flex;
  flex-direction: column;
  min-height: 100vh;
`;

const Layout = ({ outlet = <Outlet /> }: LayoutProps) => (
  <Main>
    <CssBaseline />
    <Container component="main">{outlet}</Container>
    <Footer />
  </Main>
);

export default Layout;
