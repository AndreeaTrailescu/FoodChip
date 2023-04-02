import { Autocomplete, Button, CircularProgress, Container, Grid, TextField } from "@mui/material";
import React, { useEffect, useState } from "react";
import { api, getCategories, getCookingMethods, getIngredients, getRecipes } from "../../api";
import RecipeCard from "../SearchIngredientsPage/RecipeCard/RecipeCard";
import NavBar from "../NavBar/NavBar";

const SearchIngredientsPage = () => {
    const [ingredients, setIngredients] = useState([]);
    const [searchIngredients, setSearchIngredients] = useState([]);
    const [categories, setCategories] = useState([]);
    const [cookingMethods, setCookingMethods] = useState([]);
    const [recipes, setRecipes] = useState([]);
    const [loading, setLoading] = useState(false);
    const [category, setCategory] = useState(null);
    const [cookingMethod, setCookingMethod] = useState(null);

    useEffect(() => {
        getIngredients()
        .then(response => {
            setIngredients(response.data);
        })
        .catch(error => {
            console.log(error);
        })
        getCategories()
        .then(response => {
            setCategories(response.data);
            console.log(categories);
        })
        .catch(error => {
            console.log(error)
        })
        getCookingMethods()
        .then(response => {
            setCookingMethods(response.data);
            console.log(cookingMethods);
        })
        .catch(error => {
            console.log(error)
        })
    }, [])

    const handleSearch = () => {
        const list = [];
        searchIngredients.forEach(ingr => list.push(ingr.id));
        setLoading(true);
        getRecipes(category, cookingMethod, list)
        .then(response => {
            setRecipes(response.data)
            console.log(recipes)
        })
        .catch(err => {
            console.log(err);
        })
        setLoading(false);
    }

    return(
        <>
        <>
        <NavBar />
        <Grid container justifyContent="flex-start" style={{paddingLeft: '40px', paddingRight: '40px', paddingTop: '30px'}}>
            <Grid item container xs={12} >
            <Grid item xs={8} style={{paddingRight: '30px'}}>
            <Autocomplete
            multiple
            id="tags-standard"
            options={ingredients}
            getOptionLabel={(option) => option.name}
            onChange={(event, newValue) => {setSearchIngredients(newValue)}}
            renderInput={(params) => (
            <TextField  
                {...params}
                variant="standard"
                label="Search your ingredients"
                placeholder="Ingredients"
            />
            )}
        />
            </Grid>
            <Grid item xs={2} style={{paddingRight: '30px'}}>
            <Autocomplete
            id="tags-standard"
            options={categories}
            isOptionEqualToValue={(option, value) => option.id === value.id}
            getOptionLabel={(option) => option.name}
            onChange={(event, newValue) => {setCategory(newValue == null ? null : newValue.id)}}
            renderInput={(params) => (
            <TextField  
                {...params}
                variant="standard"
                label="Choose category"
                placeholder="Categories"
            />
            )}
        />
            </Grid>
            <Grid item xs={2} style={{paddingRight: '30px'}}>
            <Autocomplete
            id="tags-standard"
            options={cookingMethods}
            isOptionEqualToValue={(option, value) => option.id === value.id}
            getOptionLabel={(option) => option.name}
            onChange={(event, newValue) => {setCookingMethod(newValue == null ? null : newValue.id)}}
            renderInput={(params) => (
            <TextField  
                {...params}
                variant="standard"
                label="Choose cooking method"
                placeholder="Cooking Methods"
            />
            )}
        />
            </Grid>
            <Grid item xs={1} style={{paddingTop: '10px'}}>
                <Button variant="contained" onClick={handleSearch} style={{background: '#FEA150'}}>Search</Button>
            </Grid>
            </Grid>
            {loading && 
            <Grid container spacing={0} direction="column" alignItems="center" justifyContent="center" marginTop={10}>
            <CircularProgress /> 
            </Grid>
            }
            {!loading && 
            <Grid item container xs={12} spacing={6} style={{paddingTop: '30px', paddingBottom: '30px'}}>
                    {recipes.map( (recipe) => {
                        return (
                            <Grid item xs={3}>
                                <RecipeCard key={recipe.id} recipe={recipe} />
                            </Grid>
                        )
                    })}
            </Grid>
            }
        </Grid>
        </>
        </>
    );
}

export default SearchIngredientsPage;