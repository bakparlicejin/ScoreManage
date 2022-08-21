prompt PL/SQL Developer Export User Objects for user SCOTT@ORCL
prompt Created by Administrator on 2022��8��21��
set define off
spool database.log

prompt
prompt Creating table EDU_ACTION
prompt =========================
prompt
create table SCOTT.EDU_ACTION
(
  id          INTEGER not null,
  name        NVARCHAR2(20),
  description NVARCHAR2(20),
  addtime     DATE default SYSDATE not null,
  isenable    CHAR(1 CHAR) default 1 not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
comment on column SCOTT.EDU_ACTION.id
  is '����';
comment on column SCOTT.EDU_ACTION.name
  is 'Ȩ������';
comment on column SCOTT.EDU_ACTION.description
  is 'Ȩ������';
comment on column SCOTT.EDU_ACTION.addtime
  is '���ʱ��';
comment on column SCOTT.EDU_ACTION.isenable
  is '�Ƿ����� 0�������� 1������ Ĭ������';
alter table SCOTT.EDU_ACTION
  add constraint EDU_ACTION_PK primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table EDU_CLASS
prompt ========================
prompt
create table SCOTT.EDU_CLASS
(
  id       INTEGER not null,
  name     NVARCHAR2(10) not null,
  isenable CHAR(1 CHAR) default 1 not null,
  addtime  DATE default sysdate not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
comment on column SCOTT.EDU_CLASS.id
  is '����';
comment on column SCOTT.EDU_CLASS.name
  is '����';
comment on column SCOTT.EDU_CLASS.isenable
  is '�Ƿ���� 0�������� 1������  Ĭ��1';
comment on column SCOTT.EDU_CLASS.addtime
  is '���ʱ��';
alter table SCOTT.EDU_CLASS
  add constraint EDU_CLASS_PK primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table EDU_CLASS_TEACHER
prompt ================================
prompt
create table SCOTT.EDU_CLASS_TEACHER
(
  teacherid INTEGER not null,
  classid   INTEGER not null,
  roleid    NUMBER
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
comment on column SCOTT.EDU_CLASS_TEACHER.teacherid
  is '��ʦId';
comment on column SCOTT.EDU_CLASS_TEACHER.classid
  is '�༶Id';
comment on column SCOTT.EDU_CLASS_TEACHER.roleid
  is '��ʦ��ɫid';

prompt
prompt Creating table EDU_EXAM
prompt =======================
prompt
create table SCOTT.EDU_EXAM
(
  id        INTEGER not null,
  subjectid INTEGER not null,
  name      NVARCHAR2(20)
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255;
comment on column SCOTT.EDU_EXAM.id
  is '����';
comment on column SCOTT.EDU_EXAM.subjectid
  is '��ĿId';
comment on column SCOTT.EDU_EXAM.name
  is '��������';
alter table SCOTT.EDU_EXAM
  add constraint EDU_EXAM_PK primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255;

prompt
prompt Creating table EDU_EXAMDETIAL
prompt =============================
prompt
create table SCOTT.EDU_EXAMDETIAL
(
  id        INTEGER not null,
  studentid INTEGER not null,
  examid    INTEGER not null,
  score     FLOAT default 0,
  teacherid INTEGER
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255;
comment on column SCOTT.EDU_EXAMDETIAL.id
  is '����';
comment on column SCOTT.EDU_EXAMDETIAL.studentid
  is 'ѧ��id';
comment on column SCOTT.EDU_EXAMDETIAL.examid
  is '����Id';
comment on column SCOTT.EDU_EXAMDETIAL.score
  is '����';
comment on column SCOTT.EDU_EXAMDETIAL.teacherid
  is '��������ʦid';
alter table SCOTT.EDU_EXAMDETIAL
  add constraint EDU_EXAMDETIAL_PK primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255;

prompt
prompt Creating table EDU_ROLE
prompt =======================
prompt
create table SCOTT.EDU_ROLE
(
  id          INTEGER not null,
  description NVARCHAR2(30),
  name        NVARCHAR2(10),
  addtime     DATE default SYSDATE not null,
  isenable    CHAR(1) default 1 not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
comment on column SCOTT.EDU_ROLE.id
  is '����';
comment on column SCOTT.EDU_ROLE.description
  is '����';
comment on column SCOTT.EDU_ROLE.name
  is '��ɫ����';
comment on column SCOTT.EDU_ROLE.addtime
  is '���ʱ��';
comment on column SCOTT.EDU_ROLE.isenable
  is '�Ƿ����� 0�������� 1������ Ĭ������';
alter table SCOTT.EDU_ROLE
  add constraint EDU_ROLE_PK primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table EDU_ROLE_ACTION
prompt ==============================
prompt
create table SCOTT.EDU_ROLE_ACTION
(
  roleid   INTEGER not null,
  actionid INTEGER not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
comment on column SCOTT.EDU_ROLE_ACTION.roleid
  is '��ɫid';
comment on column SCOTT.EDU_ROLE_ACTION.actionid
  is 'Ȩ��id';

prompt
prompt Creating table EDU_STUDENT
prompt ==========================
prompt
create table SCOTT.EDU_STUDENT
(
  id      INTEGER not null,
  classid INTEGER,
  name    NVARCHAR2(10),
  userid  INTEGER
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
comment on column SCOTT.EDU_STUDENT.id
  is '����';
comment on column SCOTT.EDU_STUDENT.classid
  is '�༶id';
comment on column SCOTT.EDU_STUDENT.name
  is '����';
comment on column SCOTT.EDU_STUDENT.userid
  is '�û�id';
alter table SCOTT.EDU_STUDENT
  add constraint EDU_STUDENT_PK primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table EDU_SUBJECT
prompt ==========================
prompt
create table SCOTT.EDU_SUBJECT
(
  id          INTEGER not null,
  name        NVARCHAR2(20),
  description NVARCHAR2(20),
  isenable    CHAR(1 CHAR) default 1 not null,
  addtime     DATE default sysdate not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
comment on column SCOTT.EDU_SUBJECT.id
  is '����';
comment on column SCOTT.EDU_SUBJECT.name
  is 'ѧ������';
comment on column SCOTT.EDU_SUBJECT.description
  is 'ѧ������';
comment on column SCOTT.EDU_SUBJECT.isenable
  is '�Ƿ����� 0 ������ 1 ����Ĭ������';
comment on column SCOTT.EDU_SUBJECT.addtime
  is '���ʱ��';
alter table SCOTT.EDU_SUBJECT
  add constraint EDU_SUBJECT_PK primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table EDU_SUGGESTIONS
prompt ==============================
prompt
create table SCOTT.EDU_SUGGESTIONS
(
  id           INTEGER not null,
  teacherid    INTEGER not null,
  studentid    INTEGER not null,
  content      NVARCHAR2(200),
  examdetailid INTEGER not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255;
comment on column SCOTT.EDU_SUGGESTIONS.id
  is '����';
comment on column SCOTT.EDU_SUGGESTIONS.teacherid
  is '��ʦId';
comment on column SCOTT.EDU_SUGGESTIONS.studentid
  is 'ѧ��id';
comment on column SCOTT.EDU_SUGGESTIONS.content
  is '��������';
comment on column SCOTT.EDU_SUGGESTIONS.examdetailid
  is '����Id';
alter table SCOTT.EDU_SUGGESTIONS
  add constraint EDU_SUGGESTIONS_PK primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255;

prompt
prompt Creating table EDU_TEACHER
prompt ==========================
prompt
create table SCOTT.EDU_TEACHER
(
  id            INTEGER not null,
  email_address VARCHAR2(20 CHAR),
  phone_number  VARCHAR2(11 CHAR),
  name          NVARCHAR2(10) not null,
  userid        INTEGER not null,
  subjectid     INTEGER,
  isdelete      CHAR(1) default 1 not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
comment on column SCOTT.EDU_TEACHER.id
  is '����';
comment on column SCOTT.EDU_TEACHER.email_address
  is '�����ַ';
comment on column SCOTT.EDU_TEACHER.phone_number
  is '�绰����';
comment on column SCOTT.EDU_TEACHER.name
  is '��ʦ����';
comment on column SCOTT.EDU_TEACHER.userid
  is '�û�Id';
comment on column SCOTT.EDU_TEACHER.subjectid
  is 'ѧ��id';
comment on column SCOTT.EDU_TEACHER.isdelete
  is '�Ƿ���ɾ�� 0����ɾ�� 1��δɾ�� Ĭ��1';
alter table SCOTT.EDU_TEACHER
  add constraint EDU_TEACHER_PK primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating table EDU_TEACHER_ROLE
prompt ===============================
prompt
create table SCOTT.EDU_TEACHER_ROLE
(
  teacherid INTEGER not null,
  roleid    INTEGER not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
comment on column SCOTT.EDU_TEACHER_ROLE.teacherid
  is '��ʦid';
comment on column SCOTT.EDU_TEACHER_ROLE.roleid
  is '��ɫid';

prompt
prompt Creating table EDU_USER
prompt =======================
prompt
create table SCOTT.EDU_USER
(
  id       INTEGER not null,
  username VARCHAR2(20 CHAR) not null,
  password VARCHAR2(20 CHAR) not null,
  type     NUMBER(1) default 0 not null,
  isenable CHAR(1) default 1 not null
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
comment on column SCOTT.EDU_USER.id
  is '����';
comment on column SCOTT.EDU_USER.username
  is '��¼����';
comment on column SCOTT.EDU_USER.password
  is '����';
comment on column SCOTT.EDU_USER.type
  is '�û����� 0������Ա 1����ʦ 2��ѧ��';
comment on column SCOTT.EDU_USER.isenable
  is '�Ƿ����� 0��δ���� 1��������  Ĭ��1';
alter table SCOTT.EDU_USER
  add constraint EDU_USER_PK primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

prompt
prompt Creating sequence SEQ_ID
prompt ========================
prompt
create sequence SCOTT.SEQ_ID
minvalue 1
maxvalue 99999999
start with 150
increment by 1
nocache
order;


prompt Done
spool off
set define on
