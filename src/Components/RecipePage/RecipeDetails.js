import { CircularProgress, Typography } from "@mui/material";
import React, { useEffect, useState, FlatList } from "react";
import { getRecipe } from "../../api";

const RecipeDetails = ({id}) => {
    const [recipes, setRecipes] = useState(null);

    useEffect(() => {
        getRecipe(id)
        .then((response) => {
            console.log(response.data);
            setRecipes(response.data);
        })
        .catch(function (error) {
            console.log(error);
        });
    });

    return(
        <>
        {!recipes ? <CircularProgress /> :
            <>
            <div style={{display: 'flex', justifyContent: 'center', marginTop: 30, marginRight: 70, marginBottom: 30}}>
                <div style={{height:350, width:400, marginRight: 50}}>
                    <img src={recipes.photo} alt="" style={{height: '100%', width: '100%', fill: 'cover'}}/>
                </div>
                <div style={{display: 'flex', flexDirection: 'column', maxWidth: '600px'}}>
                    <div style={{marginBottom: 20}}>
                        <Typography variant="h4">{recipes.name}</Typography>
                    </div>
                    <div style={{fontStyle: 'italic'}}>
                        <Typography variant="h6">{'Ingredients:'}</Typography>
                    </div>
                    <div style={{marginBottom: 20}}>
                        {recipes.ingredients.map((ing) => (
                            <Typography key={ing.id}>{'\u2022'} {ing.name}</Typography>
                        ))}
                    </div>
                    <div>
                        <Typography>{recipes.description}</Typography>
                    </div>
                </div>
            </div>
            </>
        }
        </>
    );
}

export default RecipeDetails;