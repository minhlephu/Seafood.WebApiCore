import { Route, Routes } from "react-router-dom";
import routesCommon from "../commons/routes.common";
import Dashboard from "../pages/dashboard";

const DashboardRouter = () => {
  return (
    <Routes>
      <Route index element={<Dashboard />} />
      {routesCommon.routesDasboard.map((r) => {
        return <Route key={r.path} path={r.path} element={r.element} />;
      })}
    </Routes>
  );
};

export default DashboardRouter;
