import { Route, Routes } from "react-router-dom"
import routesCommon from "../commons/routes.common";
import CategoryListComponent from "../components/categories/category-list.component";

const CategoryRouter = () => {
    return (
        <Routes>
            <Route index element={<CategoryListComponent />} />
            {
                routesCommon.routesCategory.map(r => {
                    return <Route key={r.path} path={r.path} element={r.element} />
                })
            }
        </Routes>
    )
}

export default CategoryRouter;