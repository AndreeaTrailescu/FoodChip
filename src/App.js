import React from "react"
import LandingPage from "./Components/LandingPage/LandingPage"
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import SearchIngredientsPage from "./Components/SearchIngredientsPage/SearchIngredientsPage"
import RecipePage from "./Components/RecipePage/RecipePage"

const App = () => {
    return (
                <BrowserRouter>
                    <Routes>
                        <Route exact path="/" element={<LandingPage />} />
                        <Route exact path="/search" element={<SearchIngredientsPage />} />
                        <Route exact path="/recipes/:id" element={<RecipePage />} />
                    </Routes>
                </BrowserRouter>

    )
}

export default App