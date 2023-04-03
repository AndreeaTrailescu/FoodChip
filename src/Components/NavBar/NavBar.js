import { AppBar, Button, Container, Grid, IconButton, Toolbar } from "@mui/material";
import { Box } from "@mui/system";
import React from "react";
import { NavLink, useNavigate } from "react-router-dom";
import logo from '../../Images/logo2.png';
import 'typeface-roboto';

const NavBar = () => {
    const userRole = localStorage.getItem('role');
    const pathname = window.location.pathname;
    console.log(pathname);
    const navigate = useNavigate();

    const handleLogout = () => {
        localStorage.clear();
        navigate('/');
    }

    return(
    <>
        <AppBar position="static" style={{background: 'none', boxShadow: "none"}}>
            <Container maxWidth="xl">
                <Toolbar disableGutters>
                    <Grid container>
                        <Grid item xs>
                        <NavLink to="/" style={{color: "white", textDecoration: "none"}}>
                            <Box sx={{display: 'inline-flex'}}>
                            <IconButton size="large"
                            edge="start"
                            color="inherit"
                            aria-label="menu"
                            sx={{ mr: 2 }}
                            height={50}>
                                <img src={logo} alt="" height={100} />
                            </IconButton>
                            </Box>
                            </NavLink>
                        </Grid>
                    </Grid>
                    <Button variant="text" onClick={(e) => navigate('/search')} style={pathname === '/search' ? {fontWeight: 700, color: 'black' , width: 400, textDecoration: 'none'} : { color: 'black', width: 1000, textDecoration: 'none'}}>Search Your Ingredients</Button>
                </Toolbar>
            </Container>
        </AppBar>
    </>
    );
}

export default NavBar;