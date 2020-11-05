import React, { useContext } from "react";
import { Switch, Route, Redirect, withRouter } from "react-router-dom";
import { UserContext } from "../Providers/UserProvider.js";
import DashBoard from "./Home/DashBoard";
import ProfileDetails from "./Profile/ProfileDetails";
import Login from "./Login";
import Register from "./Register";

export default function ApplicationViews() {

    //modularize views

    const views = [
        {
            name: "DashBoard",
            component: withRouter(DashBoard),
            path: "/",
            to: "/login"
        },
        {
            name: "User Details",
            component: withRouter(ProfileDetails),
            pather: "/profile",
            to: "/login"
        },

    ]

    const { isLoggedIn } = useContext(UserContext);
    //mapping 'views' object array into an array of routes and components

    const routes = views.map((element, index) => {
        return (
            <Route key={index} path={element.path} exact>
                {isLoggedIn ? <element.component /> : <Redirect to={element.to} />}
            </Route>
        )
    })

    return (
        <main>
            <Switch>
                <Route path="/login">
                    <Login />
                </Route>
                <Route path="/register">
                    <Register />
                </Route>
                {routes}
            </Switch>
        </main>
    );
};
