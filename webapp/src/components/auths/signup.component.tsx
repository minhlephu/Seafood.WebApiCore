import {
  Avatar,
  Box,
  Button,
  Checkbox,
  Container,
  CssBaseline,
  FormControlLabel,
  Grid,
  Link,
  TextField,
  Typography,
} from "@mui/material";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import React, { useState } from "react";
import userAPI from "../../apis/UserAPI";
import { useNavigate } from "react-router-dom";

const SignUpComponent = () => {
  const navigate = useNavigate();

  const [signUpModel, setSignUpModel] = useState({
    userName: "",
    password: "",
    displayName: "",
    mobile: "",
    email: "",
  });

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    await userAPI
      .signUp(signUpModel)
      .then((res) => {
        navigate("/auth/signin");
      })
      .catch((error) => console.log(error));
  };

  const handleInputUserName = (userName: string) => {
    setSignUpModel((state) => {
      return {
        ...state,
        userName,
      };
    });
  };

  const handleInputPassword = (password: string) => {
    setSignUpModel((state) => {
      return {
        ...state,
        password,
      };
    });
  };

  const handleInputDisplayName = (displayName: string) => {
    setSignUpModel((state) => {
      return {
        ...state,
        displayName,
      };
    });
  };

  const handleInputMobile = (mobile: string) => {
    setSignUpModel((state) => {
      return {
        ...state,
        mobile,
      };
    });
  };

  const handleInputEmail = (email: string) => {
    setSignUpModel((state) => {
      return {
        ...state,
        email,
      };
    });
  };

  return (
    <Container component="main" maxWidth="xs">
      <CssBaseline />
      <Box
        sx={{
          marginTop: 8,
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
        }}
      >
        <Avatar sx={{ m: 1, bgcolor: "secondary.main" }}>
          <LockOutlinedIcon />
        </Avatar>
        <Typography component="h1" variant="h5">
          Sign up
        </Typography>
        <Box component="form" noValidate={false} onSubmit={handleSubmit} sx={{ mt: 3 }}>
          <Grid container spacing={2}>
            <Grid item xs={12}>
              <TextField
                autoComplete="given-name"
                name="displayName"
                required
                fullWidth
                id="displayName"
                label="Display Name"
                onChange={(e) => handleInputDisplayName(e.target.value)}
                autoFocus
              />
            </Grid>
            <Grid item xs={12}>
              <TextField
                required
                fullWidth
                id="mobile"
                label="Mobile"
                name="mobile"
                autoComplete="mobile"
                onChange={(e) => handleInputMobile(e.target.value)}
              />
            </Grid>
            <Grid item xs={12}>
              <TextField
                autoComplete="given-name"
                name="username"
                required
                fullWidth
                id="username"
                label="Username"
                onChange={(e) => handleInputUserName(e.target.value)}
                autoFocus
              />
            </Grid>
            <Grid item xs={12}>
              <TextField
                required
                fullWidth
                id="email"
                label="Email"
                name="email"
                autoComplete="family-name"
                onChange={(e) => handleInputEmail(e.target.value)}
              />
            </Grid>
            <Grid item xs={12}>
              <TextField
                required
                fullWidth
                name="password"
                label="Password"
                type="password"
                id="password"
                autoComplete="new-password"
                onChange={(e) => handleInputPassword(e.target.value)}
              />
            </Grid>
            <Grid item xs={12}>
              <FormControlLabel
                control={<Checkbox value="allowExtraEmails" color="primary" />}
                label="I want to receive inspiration, marketing promotions and updates via email."
              />
            </Grid>
          </Grid>
          <Button
            type="submit"
            fullWidth
            variant="contained"
            sx={{ mt: 3, mb: 2 }}
          >
            Sign Up
          </Button>
          <Grid container justifyContent="flex-end">
            <Grid item>
              <Link href="/auth/signin" variant="body2">
                Already have an account? Sign in
              </Link>
            </Grid>
          </Grid>
        </Box>
      </Box>
    </Container>
  );
};

export default SignUpComponent;
