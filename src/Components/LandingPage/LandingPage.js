import { Button } from "@mui/material";
import React from "react";
import './LandingPage.css';
import { useNavigate } from "react-router-dom";
import NavBar from "../NavBar/NavBar";

export default function LandingPage() {
    const navigate = useNavigate();

    return (
        <>
        <div id="wrapper">
            <div className="eclipse"></div>
            <NavBar/>
            <div className="grid">
                <div>
                    <div className="par">
                    What's your eating mood today?
                    </div>
                    <div className="subpar">
                    Have you ever wonder what to cook next? FoodChip is the web application for you. All you have to do is to choose the ingredients from your fridge and be amazed to see the multitude of recipes you can try.
                    </div>
                </div>
            </div>
        </div>
        </>
    );
}