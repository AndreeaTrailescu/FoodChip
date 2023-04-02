import React from "react"
import LandingPage from "./Components/LandingPage/LandingPage"
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import SearchIngredientsPage from "./Components/SearchIngredientsPage/SearchIngredientsPage"

const App = () => {
    return (
                <BrowserRouter>
                    <Routes>
                        <Route exact path="/" element={<LandingPage />} />
                        <Route exact path="/search" element={<SearchIngredientsPage />} />
                    </Routes>
                </BrowserRouter>

    )
}

export default App