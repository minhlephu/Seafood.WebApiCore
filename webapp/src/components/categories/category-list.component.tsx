import {
  ButtonGroup,
  Divider,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TablePagination,
  TableRow,
  Typography,
  styled,
  tableCellClasses,
} from "@mui/material";
import { useEffect, useState } from "react";
import categoryAPI from "../../apis/CategoryAPI";
import React from "react";
import CreateCategoryComponent from "./create-category.component";
import UpdateCategoryComponent from "./update-category.component";
import DeleteCategoryComponent from "./delete-category.component";

const StyledTableCell = styled(TableCell)(({ theme }) => ({
  [`&.${tableCellClasses.head}`]: {
    backgroundColor: theme.palette.common.black,
    color: theme.palette.common.white,
  },
  [`&.${tableCellClasses.body}`]: {
    fontSize: 14,
  },
}));

const StyledTableRow = styled(TableRow)(({ theme }) => ({
  "&:nth-of-type(odd)": {
    backgroundColor: theme.palette.action.hover,
  },
  // hide last border
  "&:last-child td, &:last-child th": {
    border: 0,
  },
}));

const CategoryListComponent: React.FC = () => {
  const [categories, setCategories] = useState([
    {
      id: "",
      name: "",
      description: "",
      note: "",
      code: "",
      icon: "",
      isDeleted: false,
      deletedAt: null,
      deletedBy: "",
      createdAt: null,
      createdBy: "",
      updateAt: null,
      updateBy: "",
    },
  ]);

  const [page, setPage] = useState(0);
  const [rowsPerPage, setRowsPerPage] = useState(5);

  const handleChangePage = (event: unknown, newPage: number) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (
    event: React.ChangeEvent<HTMLInputElement>
  ) => {
    setRowsPerPage(+event.target.value);
    setPage(0);
  };

  useEffect(() => {
    const fetchData = async () => {
      const res = await categoryAPI.getAll();
      setCategories(res.data);
    };
    fetchData().then();
  }, []);

  return (
    <>
      <Typography component={"h2"} variant="h2">
        Category List
      </Typography>
      <Divider />
      <CreateCategoryComponent onClick={() => {}} />
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 700 }} aria-label="customized table">
          <TableHead>
            <TableRow>
              <StyledTableCell>ID</StyledTableCell>
              <StyledTableCell align="left">Name</StyledTableCell>
              <StyledTableCell align="left">Description</StyledTableCell>
              <StyledTableCell align="left">Note</StyledTableCell>
              <StyledTableCell align="left">Code</StyledTableCell>
              <StyledTableCell align="left">Icon</StyledTableCell>
              <StyledTableCell align="center">Action</StyledTableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {categories
              .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
              .map((category) => (
                <StyledTableRow>
                  <StyledTableCell key={category.id} component="th" scope="row">
                    {category.id}
                  </StyledTableCell>
                  <StyledTableCell align="left">
                    {category.name}
                  </StyledTableCell>
                  <StyledTableCell align="left">
                    {category.description}
                  </StyledTableCell>
                  <StyledTableCell align="left">
                    {category.note}
                  </StyledTableCell>
                  <StyledTableCell align="left">
                    {category.code}
                  </StyledTableCell>
                  <StyledTableCell align="left">
                    {category.icon}
                  </StyledTableCell>
                  <StyledTableCell align="center">
                    <ButtonGroup
                      variant="text"
                      aria-label="text button group"
                      color={"inherit"}
                    >
                      <UpdateCategoryComponent
                        onClick={() => {}}
                        id={category.id}
                      />
                      <DeleteCategoryComponent
                        onClick={() => {}}
                        id={category.id}
                        name={category.name}
                        isDeleted={category.isDeleted}
                      />
                    </ButtonGroup>
                  </StyledTableCell>
                </StyledTableRow>
              ))}
          </TableBody>
        </Table>
      </TableContainer>
      <TablePagination
        rowsPerPageOptions={[5, 10, 15]}
        component="div"
        count={categories.length}
        rowsPerPage={rowsPerPage}
        page={page}
        onPageChange={handleChangePage}
        onRowsPerPageChange={handleChangeRowsPerPage}
      />
    </>
  );
};

export default CategoryListComponent;
