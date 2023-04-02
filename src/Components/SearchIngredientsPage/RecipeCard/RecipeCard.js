import { Grid, Typography } from "@mui/material";
import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import Card from '@mui/material/Card';
import CardMedia from '@mui/material/CardMedia';
import CardContent from '@mui/material/CardContent';
import CardActions from '@mui/material/CardActions';
import FavoriteIcon from '@mui/icons-material/Favorite';
import IconButton from '@mui/material/IconButton';
import CheckIcon from '@mui/icons-material/Check';
import ClearIcon from '@mui/icons-material/Clear';
import './RecipeCard.css';
import api from "../../../Services/api";
import { grey, red } from "@mui/material/colors";

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