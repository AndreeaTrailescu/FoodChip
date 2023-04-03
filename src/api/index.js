import axios from "axios";

export const api = axios.create({ baseURL: 'https://localhost:7025/' });

export const getCategories = () => api.get('categories');
export const getCookingMethods = () => api.get('cooking-methods');
export const getIngredients = () => api.get('ingredients');
export const getRecipe = (recipesId) => api.get(`recipes/${recipesId}`);
export const getRecipes = (categoryId, cookingMethodId, ingredientIds) => {
    var path = `recipes?`;
    if (categoryId != null){
        path = path.concat(`CategoryId=${categoryId}`);
    }
    if (categoryId != null && cookingMethodId != null){
        path = path.concat(`&CookingMethodId=${cookingMethodId}`);
    }
    if (categoryId == null && cookingMethodId != null){
        path = path.concat(`CookingMethodId=${cookingMethodId}`);
    }
    ingredientIds.map(id => {
        path = path.concat(`&IngredientIds=${id}`)
    })
    return api.get(path);
}
