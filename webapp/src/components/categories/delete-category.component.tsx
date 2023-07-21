import {
  Button,
  Dialog,
  DialogTitle,
  DialogContent,
  DialogContentText,
  DialogActions,
} from "@mui/material";
import { useState } from "react";
import categoryAPI from "../../apis/CategoryAPI";

type Props = {
  onClick: () => void,
  id: string,
  name: string
  isDeleted: boolean
};

const DeleteCategoryComponent: React.FC<Props> = ({ id, name, isDeleted}) => {
  const [open, setOpen] = useState(false);

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  const handleSave = () => {
    categoryAPI
      .delete(id)
      .then(() => {
        setOpen(false);
        window.location.reload();
      })
      .catch(() => {
        setOpen(false);
      });
  };

  return (
    <div>
      <Button onClick={handleClickOpen} disabled={!isDeleted}>
        Delete
      </Button>
      <Dialog
        open={open}
        onClose={handleClose}
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
      >
        <DialogTitle id="alert-dialog-title">
          {`Do you want to delete category "${name}"?`}
        </DialogTitle>
        <DialogContent>
          <DialogContentText id="alert-dialog-description"></DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button variant="contained" color="error" onClick={handleClose}>No</Button>
          <Button variant="contained" color="primary" onClick={handleSave} autoFocus>
            Yes
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
};

export default DeleteCategoryComponent;
