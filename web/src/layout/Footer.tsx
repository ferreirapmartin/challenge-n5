import { Box, Typography } from '@mui/material';
import styled from '@emotion/styled';

const FooterContainer = styled(Box)`
  padding: 0.2em;
  margin-top: auto;
  text-align: center;
`;

const Footer = () => (
  <FooterContainer component="footer">
    <Typography variant="body1">Challenge N5</Typography>
  </FooterContainer>
);

export default Footer;
