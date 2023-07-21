import { Route, Routes } from "react-router-dom";
import SignInComponent from "../components/auths/signin.component";
import routesCommon from "../commons/routes.common";

const AuthRouter = () => {
  return (
    <Routes>
      <Route index element={<SignInComponent />} />
      {
        routesCommon.routesAuth.map(r => {
          return <Route key={r.path} path={r.path} element={r.element} />
        }) 
      }
    </Routes>
  )
};

export default AuthRouter;
