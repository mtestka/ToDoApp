import EditTaskForm from './EditTaskForm'
import FormModal from '../../FormModal'

function EditTaskModal(props) {
    return (
        <FormModal setOpen={props.setOpen} open={props.open} form={"editTaskForm"} acceptButtonTitle={"Edit"} title={"Edit task"}>
            <EditTaskForm onSubmit={() => props.setOpen(false)} id={props.id} />
        </FormModal>
    )
}

export default EditTaskModal;