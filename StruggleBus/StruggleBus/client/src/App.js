
import { BrowserRouter as Router } from "react-router-dom";
import './App.css';
import { UserProvider } from "./Providers/UserProvider";
import { MessageProvider } from "./Providers/MessageProvider";
import ApplicationViews from "./Components/ApplicationViews";
import Header from "./Components/Header";

function App() {
  return (
    <Router>
      <UserProvider>
        <MessageProvider>
          <Header />
          <ApplicationViews />
        </MessageProvider>
      </UserProvider>
    </Router>
  );
}

export default App;
