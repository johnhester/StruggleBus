
import { BrowserRouter as Router } from "react-router-dom";
import './App.css';
import { UserProvider } from "./Providers/UserProvider";
import ApplicationViews from "./Components/ApplicationViews";

function App() {
  return (
    <Router>
      <UserProvider>
        <ApplicationViews />
      </UserProvider>
    </Router>
  );
}

export default App;
