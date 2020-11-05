
import { BrowserRouter as Router } from "react-router-dom";
import './App.css';
import { UserProvider } from "./Providers/UserProvider";
import ApplicationViews from "./Components/ApplicationViews";
import Header from "./Components/Header";

function App() {
  return (
    <Router>
      <UserProvider>
        <Header />
        <ApplicationViews />
      </UserProvider>
    </Router>
  );
}

export default App;
