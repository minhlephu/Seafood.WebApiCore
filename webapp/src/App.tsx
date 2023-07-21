import "./App.css";
import { Route, Routes } from "react-router-dom";
import routesCommon from "./commons/routes.common";
import SignInComponent from "./components/auths/signin.component";

function App() {
  return (
    <Routes>
      <Route index element={<SignInComponent />} />
      {
        routesCommon.routesApp.map(r => {
          return <Route key={r.path} path={r.path} element={r.element}/>
        })
      }
    </Routes>
  );
}

export default App;
