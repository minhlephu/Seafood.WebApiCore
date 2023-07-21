import {
  Button,
  Dialog,
  DialogTitle,
  DialogContent,
  Grid,
  TextField,
  FormControlLabel,
  Checkbox,
  DialogActions,
} from "@mui/material";
import React, { useEffect, useState } from "react";
import categoryAPI from "../../apis/CategoryAPI";

type Props = {
  onClick: () => void;
  id: string;
};

const UpdateCategoryComponent: React.FC<Props> = ({ id }) => {
  const [categoryModel, setCategoryModel] = useState({
    name: "",
    description: "",
    note: "",
    code: "",
    icon: "",
    isDeleted: false,
  });

  const [open, setOpen] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      const res = await categoryAPI.getById(String(id));
      setCategoryModel(res.data);
    };
    fetchData();
  }, [id]);

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
      .update(String(id), categoryModel)
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
        onClick={handleClickOpen}
      >
        Update
      </Button>
      <Dialog open={open} onClose={handleClose}>
        <DialogTitle>UPDATE CATEGORY</DialogTitle>
        <DialogContent>
          <Grid container spacing={2}>
            <Grid item xs={12} sx={{ marginTop: "10px" }}>
              <TextField
                value={id}
                name="id"
                fullWidth
                id="id"
                label="ID"
                disabled
              />
            </Grid>
            <Grid item xs={12}>
              <TextField
                value={categoryModel.name}
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
                value={categoryModel.description}
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
                value={categoryModel.note}
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
                value={categoryModel.code}
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
                value={categoryModel.icon}
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
                    checked={categoryModel.isDeleted}
                    onChange={(e) => handleInputIsDeleted(e.target.checked)}
                  />
                }
                label="Is Deleted?"
                labelPlacement="start"
              />
            </Grid>
          </Grid>
        </DialogContent>
        <DialogActions sx={{ marginBottom: "10px" }}>
          <Button variant="contained" color="error" onClick={handleClose}>
            Cancel
          </Button>
          <Button variant="contained" color="primary" onClick={handleSave}>
            Save
          </Button>
        </DialogActions>
      </Dialog>
    </React.Fragment>
  );
};

export default UpdateCategoryComponent;
