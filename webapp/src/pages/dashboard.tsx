import { Container } from "@mui/material";
import ResponsiveAppBar from "../layouts/app-bar.layout";
import CategoryListComponent from "../components/categories/category-list.component";

const Dashboard = () => {
  return (
    <>
      <ResponsiveAppBar />
      <Container sx={{marginTop: "20px"}}>
        <CategoryListComponent />
      </Container>
    </>
  );
};

export default Dashboard;
