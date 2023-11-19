import { Box, Typography } from '@mui/material';
import styled from '@emotion/styled';
import LanguagePicker from './LanguagePicker';
import ThemePicker from './ThemePicker';

const FooterContainer = styled(Box)`
  padding: 0.2em;
  margin-top: auto;
  display: flex;
  align-items: center;
  justify-content: space-around;
`;

const Footer = () => (
  <FooterContainer component="footer">
    <ThemePicker />
    <Typography variant="body1">Challenge N5</Typography>
    <LanguagePicker />
  </FooterContainer>
);

export default Footer;
