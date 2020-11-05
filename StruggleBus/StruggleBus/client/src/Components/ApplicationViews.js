import React, { useContext } from "react";
import { Switch, Route, Redirect, withRouter } from "react-router-dom";
import { UserContext } from "../Providers/UserProvider.js";
import DashBoard from "./Home/DashBoard";
import Login from "./Login";
import Register from "./Register";

export default function ApplicationViews() {

    //modularize views

    const views = [
        {
            name: "DashBoard",
            provider: "UserProvider",
            component: withRouter(DashBoard),
            path: "/",
            to: "/login"
        }
    ]

    const { isLoggedIn } = useContext(UserContext);
    //mapping 'views' object array into an array of routes and components

    const routes = views.map((element, index) => {
        return (
            <Route key={index} path={element.path} exact>
                <element.provider>
                    {isLoggedIn ? <element.component /> : <Redirect to={element.to} />}
                </element.provider>
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
