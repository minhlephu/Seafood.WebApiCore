import {
  Button,
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  TextField,
  Grid,
  Checkbox,
  FormControlLabel,
} from "@mui/material";
import React, { useState } from "react";
import categoryAPI from "../../apis/CategoryAPI";

type Props = {
  onClick: () => void;
};

const CreateCategoryComponent: React.FC<Props> = ({ onClick }) => {
  const [categoryModel, setCategoryModel] = useState({
    name: "",
    description: "",
    note: "",
    code: "",
    icon: "",
    isDeleted: false,
  });

  const [open, setOpen] = React.useState(false);

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  const handleInputName = (name: string) => {
    setCategoryModel((state) => {
      return {
        ...state,
        name,
      };
    });
  };

  const handleInputDescription = (description: string) => {
    setCategoryModel((state) => {
      return {
        ...state,
        description,
      };
    });
  };

  const handleInputNote = (note: string) => {
    setCategoryModel((state) => {
      return {
        ...state,
        note,
      };
    });
  };

  const handleInputCode = (code: string) => {
    setCategoryModel((state) => {
      return {
        ...state,
        code,
      };
    });
  };

  const handleInputIcon = (icon: string) => {
    setCategoryModel((state) => {
      return {
        ...state,
        icon,
      };
    });
  };

  const handleInputIsDeleted = (isDeleted: boolean) => {
    setCategoryModel((state) => {
      return {
        ...state,
        isDeleted,
      };
    });
  };

  const handleSave = () => {
    categoryAPI
      .create(categoryModel)
      .then(() => {
        setOpen(false);
        window.location.reload();
      })
      .catch(() => {
        setOpen(false);
      });
  };

  return (
    <React.Fragment>
      <Button
        variant={"outlined"}
        sx={{ margin: "10px 0px", color: "black", borderColor: "black" }}
        onClick={handleClickOpen}
      >
        New
      </Button>
      <Dialog open={open} onClose={handleClose}>
        <DialogTitle>NEW CATEGORY</DialogTitle>
        <DialogContent>
          <Grid container spacing={2}>
            <Grid item xs={12} sx={{ marginTop: "10px" }}>
              <TextField
                autoComplete="given-name"
                name="name"
                fullWidth
                id="name"
                label="Name"
                onChange={(e) => handleInputName(e.target.value)}
                autoFocus
              />
            </Grid>
            <Grid item xs={12}>
              <TextField
                fullWidth
                id="description"
                label="Description"
                name="description"
                autoComplete="family-name"
                onChange={(e) => handleInputDescription(e.target.value)}
              />
            </Grid>
            <Grid item xs={12}>
              <TextField
                fullWidth
                name="note"
                label="Note"
                id="note"
                autoComplete="note"
                onChange={(e) => handleInputNote(e.target.value)}
              />
            </Grid>
            <Grid item xs={12}>
              <TextField
                fullWidth
                name="code"
                label="Code"
                id="code"
                autoComplete="code"
                onChange={(e) => handleInputCode(e.target.value)}
              />
            </Grid>
            <Grid item xs={12}>
              <TextField
                fullWidth
                name="icon"
                label="Icon"
                id="icon"
                autoComplete="icon"
                onChange={(e) => handleInputIcon(e.target.value)}
              />
            </Grid>
            <Grid item xs={12}>
              <FormControlLabel
                value="top"
                control={
                  <Checkbox
                    onChange={(e) => handleInputIsDeleted(e.target.checked)}
                  />
                }
                label="Is Deleted?"
                labelPlacement="start"
              />
            </Grid>
          </Grid>
        </DialogContent>
        <DialogActions sx={{marginBottom: "10px"}}>
          <Button variant="contained" color="error" onClick={handleClose}>Cancel</Button>
          <Button variant="contained" color="primary" onClick={handleSave}>Save</Button>
        </DialogActions>
      </Dialog>
    </React.Fragment>
  );
};

export default CreateCategoryComponent;
