import Button from 'react-bootstrap/esm/Button';
import React, { useState } from 'react';
import ModalShowAddProject from './ModalShowAddProject';

function AddProject({ updateProjects }) {
  const [modalShow, setModalShow] = useState(false);

  return (
    <>
        <div style={{ display: 'flex', marginTop: '2%', marginLeft: '5%' }}>
            <h3>Kanban board</h3>
            <button type="button" className="btn btn-success"  style={{ marginLeft: '1%', height: '5%' }} onClick={() => setModalShow(true)}>Добавить проект</button>
        </div>

      <ModalShowAddProject
        title="Добавить проект"
        show={modalShow}
        onHide={() => setModalShow(false)}
        updateProjects={updateProjects} 
      />
    </>
  );
}

export default AddProject;