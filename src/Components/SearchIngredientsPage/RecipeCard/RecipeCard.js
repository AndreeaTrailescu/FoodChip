import { Grid, Typography } from "@mui/material";
import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import Card from '@mui/material/Card';
import CardMedia from '@mui/material/CardMedia';
import CardContent from '@mui/material/CardContent';
import './RecipeCard.css';

const RecipeCard = ({recipe}) => {
    const pathname = window.location.pathname;
    const navigate = useNavigate();

    const handleClick = () => {
        navigate(`/recipes/${recipe.id}`);
    }   

    return(
        <Card>
            <CardMedia
                component="img"
                height="194"
                image={recipe.photo}
                alt="Photo"
            />
            <CardContent>
                <Typography className="name" onClick={handleClick}>
                    {recipe.name}
                </Typography>
            </CardContent>
        </Card>
    );
}

export default RecipeCard;