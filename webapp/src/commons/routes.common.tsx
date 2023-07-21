import SignInComponent from "../components/auths/signin.component";
import SignUpComponent from "../components/auths/signup.component";
import CategoryListComponent from "../components/categories/category-list.component";
import AuthRouter from "../routers/auth.route";
import CategoryRouter from "../routers/category.route";
import DashboardRouter from "../routers/dashboard.route";

const routesApp = [
  {
    path: "/auth/*",
    element: <AuthRouter />,
  },
  {
    path: "/dashboards/*",
    element: <DashboardRouter />
  },
];

const routesDasboard = [
  {
    path: "/categories/*",
    element: <CategoryRouter />
  },
  {
    path: "/users/*",
    element: <AuthRouter />
  }
]

const routesAuth = [
  {
    path: "/signin",
    element: <SignInComponent />,
  },
  {
    path: "/signup",
    element: <SignUpComponent />,
  },
];

const routesCategory = [
  {
    path: "/all",
    element: <CategoryListComponent />,
  },  
];


const routesCommon = {
    routesApp,
    routesAuth,
    routesDasboard,
    routesCategory
}

export default routesCommon;